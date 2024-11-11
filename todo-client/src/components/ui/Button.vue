<template>
  <button :type="type" @click="$emit('click')" class="button">
    <slot />
  </button>
</template>

<script>
export default {
  name: "Button",
  props: {
    type: {
      type: String,
      default: "button",
    },
  },
};
</script>

<style scoped lang="scss">
.button {
  background-color: #3498db;
  border: none;
  color: #fff;
  padding: 10px 15px;
  cursor: pointer;
  border-radius: 4px;
  &:hover {
    background-color: #2980b9;
  }
}
</style>
