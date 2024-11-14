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
  border: none;
  color: #fff;
  padding: 10px 15px;
  cursor: pointer;
  border-radius: 4px;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
}
</style>
