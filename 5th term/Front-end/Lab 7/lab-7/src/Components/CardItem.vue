<template>
  <div class="card">
    <div class="img"><img :src="card.photo" alt="помилеове посилання на фото :("></div>
    <div class="card-name">{{card.name}}</div>
    <div class="card-cost">{{card.cost}} грн</div>
  </div>
</template>

<script>
export default {
    props: {
        card: {
          type: Object,
          required: true
        }
    }
}
</script>

<style scoped>
.card {
  padding: 15px;
  margin: 15px;
  border: 2px solid teal;
  min-width: 200px;
  min-height: 300px;
  transition: 0.3s transform;
}

.card:hover {
  transform: scale(1.1);

}

.card-name {
  text-align: center;
  font-weight: bold;
  color: #3AC1EF !important;
}

.card-cost {
  text-align: center;
  text-align: end;
  margin-top: 10px;
}

img {
  width: 200px;
}
</style>