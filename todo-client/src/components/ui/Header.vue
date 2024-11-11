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
  display: flex;
  justify-content: center;
  background-color: #145035;
  color: white;
  padding: 20px;
  text-align: center;
  width: 100%;
  border-radius: 5px;
  max-width: 1200px;
}

.header-icon {
  width: 40px;
}
</style>
