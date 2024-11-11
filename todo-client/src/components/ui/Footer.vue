<template>
  <footer class="footer">
    <p>&copy; {{ actualYear }} WilloS</p>
  </footer>
</template>

<script>
export default {
  name: "Footer",
  data() {
    return {
      actualYear: new Date().getFullYear(),
    };
  },
};
</script>

<style scoped lang="scss">
.footer {
  background-color: #686868;
  text-align: center;
  color: #555;
  width: 100%;
  margin-top: 20px;
}

p {
  color: white;
  font-family: "Courier New", Courier, monospace;
}
</style>
