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
@import "../../colors.scss";

.footer {
  background-color: $header-color;
  padding: 10px;
  text-align: center;
  color: #555;
  width: 100%;
  margin-top: 20px;
  position: fixed;
  bottom: 0;
  left: 0;
}

p {
  color: white;
  font-family: "Courier New", Courier, monospace;
}
</style>
