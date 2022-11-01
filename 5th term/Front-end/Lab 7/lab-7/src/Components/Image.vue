<template>
  <div class="card">
    <div id="img-container">
      <a
          class="img-wrapper"
          :style="'width:' + (imgSettings.width - 34) + 'px'"
          :href="imgSettings.href"
          target="_blank">
        <img
            :src="imgSettings.src"
            alt="помилеове посилання на фото :("
        >
      </a>
    </div>
    <div class="buttons">
      <button @click="add">Додати</button>
      <button @click="zoomIn">Збільшити</button>
      <button @click="zoomOut">Зменшити</button>
      <button @click="del">Видалити</button>
    </div>
  </div>
</template>

<script>
export default {
  props: {
    imgSettings: {
      type: Object,
      required: true
    }
  },
  methods: {
    add() {
      const container = document.getElementById('img-container');
      container.insertAdjacentHTML('beforeend', container.lastElementChild.outerHTML);
    },
    del() {
      const container = document.getElementById('img-container');
      if(container.children.length !== 1){
        container.lastElementChild.remove();
      }
    },
    zoomIn() {
      const container = document.getElementById('img-container');
      const el = container.lastElementChild.lastElementChild;
      el.style.transform += 'scale(1.4)';
    },
    zoomOut() {
      const container = document.getElementById('img-container');
      const el = container.lastElementChild.lastElementChild;
      el.style.transform += 'scale(0.7)';
    }
  }
}
</script>

<style scoped>
.card {
  padding: 15px;
  border: 2px solid teal;
  display: flex;
  flex-direction: column;
  align-items: center;
}

#img-container {
  display: flex;
  flex-wrap: wrap;
  justify-content: center;

}

img {
  width: 100%;
  height: 100%;
}

a {
  margin: 15px;
}

.img-wrapper {
  overflow: hidden;
}

.buttons {
  align-self: flex-start;
}
.buttons button {
  margin: 5px;
  align-self: flex-end;
  padding: 10px 15px;
  background: none;
  color: teal;
  border: 1px solid teal;
}

.buttons button:hover {
  background: teal;
  color: white;
}
</style>