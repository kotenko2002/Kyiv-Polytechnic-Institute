<template>
  <div class="list-wrapper">
    <h3>Вітрина товарів</h3>
    <div class="list">
      <card-item
          v-for="card in cards"
          :card="card"
      />
    </div>
  </div>
</template>

<script>
import CardItem from "@/Components/CardItem";
export default {
  components: {CardItem},
  props:{
      cards: {
        type: Array,
        required: true
      }
    }
}
</script>

<style scoped>
.list-wrapper {
  margin: 15px;
}
h3{
  text-align: center;
}

.list {
  display: flex;
  flex-wrap: wrap;
  justify-content: center;
  margin: 15px;
}
</style>