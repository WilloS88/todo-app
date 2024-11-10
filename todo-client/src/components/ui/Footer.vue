<template>
  <footer class="footer">
    <p>&copy; {{ actualYear }} WilloS</p>
  </footer>
</template>

<script>
export default {
  name: 'Footer',
  data() {
    return {
      actualYear: new Date().getFullYear()
    };
  }
};
</script>

<style scoped lang="scss">
.footer {
  background-color: #686868;
  padding: 1em;
  text-align: center;
  color: #555;
  position: fixed;
  bottom: 0;
  left: 0;
  width: 100%;
}

p {
  color: white;
  font-family: 'Courier New', Courier, monospace;
}
</style>
