<template>
  <header class="header">
    <h1>
      Todo App
      <img :src="HeaderIcon" alt="Todo App Icon" class="header-icon" />
    </h1>
  </header>
</template>

<script>
import HeaderIcon from "../../assets/HeaderIcon.svg";

export default {
  name: "Header",
  data() {
    return {
      HeaderIcon,
    };
  },
};
</script>

<style scoped lang="scss">
@import "../../colors.scss";

header {
  font-family: "Courier New", Courier, monospace;
  padding: 20px 0px 20px 0px;
  font-size: 30px;
  display: flex;
  justify-content: center;
  background-color: $header-color;
  color: white;
  text-align: center;
  width: 100%;
  height: 80%;
}

.header-icon {
  width: 40px;
}
</style>
