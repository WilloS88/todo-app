<template>
  <div class="page">
    <Header />
    <main>
      <Layout />
    </main>
    <Footer />
  </div>
</template>

<script>
import Header from './components/ui/Header.vue';
import Footer from './components/ui/Footer.vue';
import Layout from './components/Layout.vue';

export default {
  name: "App",
  components: {
    Header,
    Footer,
    Layout,
  },
}
</script>

<style scoped lang="scss">
* {
  margin: 0;
  padding: 0;  
}

body {
  padding: 0;
  background-color: rgb(93, 82, 82);

}

.page {
  display: flex;
  flex-direction: column;
  align-items: center;
  background-color: rgb(208, 208, 208);
}

main {
  flex: 1;
  display: flex;
  justify-content: center;
  margin: 10px 0px 10px 0px;
}
</style>
