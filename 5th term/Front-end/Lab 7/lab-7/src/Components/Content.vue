<template>
  <div>
    <p>Хоббі:</p>
    <ul>
      <li
          @click="firstLi=!firstLi"
          :class="{highlighting : firstLi}">
        програмування (тицьни на мене)

      </li>
      <li
          @click="secondLi=!secondLi"
          :class="{highlighting : secondLi}">
        шахи (і на мане теже)
      </li>
      <li>гирьовий спорт</li>
      <li>читання книг/манги</li>
    </ul>
    <p>Улюблені фільми:</p>
    <ol>
      <li>"Форест Гамп", 1994</li>
      <li>"Втеча із Шаушенгу", 1994</li>
      <li>"Бункер", 2011</li>
      <li>"Ідіократія", 2006</li>
      <li>"Дурак", 2014</li>
    </ol>
    <p>Яре́мче — місто в Україні, в Надвірнянському районі Івано-Франківській області.
      Розміщене на річці Прут, на автошляху Івано-Франківськ — Рахів — Ужгород.
      Залізниця зв'язує місто з обласним центром, Тернополем, Києвом, Чернівцями та Львовом.</p>
  </div>
</template>

<script>
export default {
  data() {
    return {
      firstLi: false,
      secondLi: false,
    }
  }
}
</script>

<style scoped>
li {
  margin-left: 3rem;
}

p {
  display: block;
  margin-block-start: 1em;
  margin-block-end: 1em;
  margin-inline-start: 0px;
  margin-inline-end: 0px;
}

li, p {
  font-size: 1.2rem;
}

.highlighting {
  background: rgb(255, 255, 0);
  color: rgb(0, 38, 255);
}
</style>