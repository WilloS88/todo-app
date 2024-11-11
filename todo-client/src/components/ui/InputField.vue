<template>
  <div class="input-field">
    <label>{{ label }}</label>
    <div>
      <template v-if="textarea">
        <textarea
          v-model="inputValue"
          :required="required"
          @input="updateValue($event.target.value)"
        ></textarea>
      </template>
      <template v-else>
        <input
          v-model="inputValue"
          :required="required"
          @input="updateValue($event.target.value)"
        />
      </template>
    </div>
  </div>
</template>

<script>
export default {
  name: "InputField",
  props: {
    label: String,
    modelValue: [String, Number],
    required: {
      type: Boolean,
      default: false,
    },
    textarea: {
      type: Boolean,
      default: false,
    },
  },
  emits: ["update:modelValue"],
  computed: {
    inputValue: {
      get() {
        return this.modelValue;
      },
      set(value) {
        this.$emit("update:modelValue", value);
      },
    },
  },
};
</script>

<style scoped lang="scss">
.input-field {
  margin-bottom: 10px;
  label {
    display: block;
    margin-bottom: 5px;
  }
  input,
  textarea {
    width: 100%;
    padding: 8px;
    box-sizing: border-box;
  }
}
</style>
