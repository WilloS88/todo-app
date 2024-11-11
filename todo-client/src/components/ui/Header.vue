<template>
  <header class="header">
    <h1>Todo App
      <img :src="HeaderIcon" alt="Todo App Icon" class="header-icon"/>
    </h1>
  </header>
</template>

<script>
import HeaderIcon from "../../assets/HeaderIcon.svg"

export default {
  name: "Header",
  data() {
    return {
      HeaderIcon,
    }
  }
};
</script>

<style scoped lang="scss">
header {
  font-family: 'Courier New', Courier, monospace;
  font-size: 30px;
  display: flex;
  justify-content: center;
  background-color: #145035;
  color: white;
  text-align: center;
  width: 100%;
  height: 80%;
  border-radius: 5px;
  max-width: 1000px;
}

.header-icon {
  width: 40px;
}
</style>
