<template>
    <div class="app">
      <Header/>
      <Content/>
      <Image
        :img-settings="imgSettings"/>
      <CardList
        :cards="cards"/>
    </div>
</template>

<script>
import CardList from "@/Components/CardList";
import Image from "@/Components/Image";
import Header from "@/Components/Header";
import Content from "@/Components/Content";
export default {
  components: {Header, Content, Image, CardList},
  data() {
    return {
      imgSettings: {
        src: 'https://guide.karpaty.ua/uploads/article_photos/1435735171-611676__stegka-dovbusha6.jpg',
        href: 'https://yaremcha-miskrada.gov.ua/',
        width: '500'
      },
      cards: [
        { photo: "https://png.pngtree.com/illustration/20190226/ourlarge/pngtree-fruit-mango-pulp-cut-mango-image_8588.jpg", name: 'Манго', cost : '15'},
        { photo: "https://png.pngtree.com/illustration/20190226/ourlarge/pngtree-fruit-vegetables-apple-red-image_8624.jpg", name: 'Яблуко', cost : '32'},
        { photo: "https://png.pngtree.com/illustration/20190226/ourlarge/pngtree-grapefruit-fruit-pomelo-tea-realistic-image_8751.jpg", name: 'Груша', cost : '42'},
        { photo: "https://png.pngtree.com/illustration/20190226/ourlarge/pngtree-fruit-vegetables-tomato-red-image_8498.jpg", name: 'Помідор', cost : '53'},
        { photo: "https://png.pngtree.com/illustration/20190226/ourlarge/pngtree-fruit-vegetables-carrot-radish-image_8493.jpg", name: 'Морква', cost : '52'},
        { photo: "https://png.pngtree.com/illustration/20190226/ourlarge/pngtree-fruit-vegetables-eggplant-purple-image_8496.jpg", name: 'Баклажан', cost : '9'},
        { photo: "https://png.pngtree.com/illustration/20190226/ourlarge/pngtree-fruit-vegetables-lemon-yellow-image_8565.jpg", name: 'Лемон', cost : '70'},
        { photo: "https://png.pngtree.com/illustration/20190226/ourlarge/pngtree-fruit-vegetables-melon-yellow-image_8669.jpg", name: 'Гарбуз', cost : '89'},
      ]
    }
  }
}
</script>

<style>
* {
  margin: 0;
  padding: 0;
  box-sizing: border-box;
}

.app {
  padding: 20px;
  display: flex;
  flex-wrap: wrap;
  flex-direction: column;
}
</style>