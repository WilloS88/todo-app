<template>
  <div class="page">
    <Header />
    <test />
    <main>
      <Layout />
    </main>
    <Footer />
  </div>
</template>

<script>
import Header from "./components/ui/Header.vue";
import Footer from "./components/ui/Footer.vue";
import Layout from "./components/Layout.vue";
import test from "./test.vue";

export default {
  name: "App",
  components: {
    Header,
    Footer,
    Layout,
    test,
  },
};
</script>

<style scoped lang="scss">
@import "colors.scss";

.page {
  display: flex;
  flex-direction: column;
  align-items: center;
  background-color: $layout-background-color;
}

main {
  display: flex;
  justify-content: center;
  align-items: center;
  margin: 10px 0px 10px 0px;
}
</style>
