
<template>
  <div class="page">
    <Header />
    <main>
      <Layout />
    </main>
    <Footer />
  </div>
</template>

  <script setup lang="js">
  import Header from './components/ui/Header.vue';
  import Footer from './components/ui/Footer.vue';
  import Layout from './components/Layout.vue';
  </script>

<style scoped lang="scss">
:root {
  font-family: 'Courier New', Courier, monospace;
}

* {
  margin: 0px;
  padding: 0px;
}

body {
  margin: 0px;
  padding: 0px;
}

.page {
  display: flex;
  flex-direction: column;
  min-height: 100vh;
}

main {
  flex: 1;
  display: flex;
  justify-content: center;
  padding: 10px;
}


</style>
