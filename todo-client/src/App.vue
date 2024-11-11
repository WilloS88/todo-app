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
  overflow: hidden;
  background-color: rgb(239, 239, 239);
}

body {
  margin: 0 !important; 
  padding: 0;
}

.page {
  display: flex;
  flex-direction: column;
  align-items: center;
}

main {
  flex: 1;
  display: flex;
  justify-content: center;
  margin: 10px 0px 10px 0px;
}
</style>
