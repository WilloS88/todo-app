<template>
  <div class="modal-overlay" @click.self="closeModal">
    <div class="modal-content">
      <button class="close-button" @click="closeModal">&times;</button>
      <slot></slot>
    </div>
  </div>
</template>

<script>
export default {
  name: "Modal",
  emits: ["close"],
  methods: {
    closeModal() {
      this.$emit("close");
    },
    handleKeydown(event) {
      if (event.key === "Escape") {
        this.closeModal();
      }
    },
  },
  mounted() {
    document.addEventListener("keydown", this.handleKeydown);
  },
  beforeUnmount() {
    document.removeEventListener("keydown", this.handleKeydown);
  },
};
</script>

<style scoped lang="scss">
@import "../../colors.scss";

.modal-overlay {
  color: #fff;
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background-color: rgba(0, 0, 0, 0.5);
  display: flex;
  justify-content: center;
  align-items: center;
}
.modal-content {
  display: flex;
  flex-direction: column;
  gap: 10px;
  font-family: "Courier New", Courier, monospace;
  background-color: $secondary-color;
  padding: 20px;
  position: relative;
  width: 90%;
  max-width: 500px;
  border-radius: 8px;
}
.close-button {
  color: white;
  position: absolute;
  top: 10px;
  right: 15px;
  background: none;
  border: none;
  font-size: 1.5rem;
  cursor: pointer;
}
</style>
