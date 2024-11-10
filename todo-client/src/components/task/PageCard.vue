<script>
import { defineComponent } from "vue";
import InputField from "../ui/InputField.vue";

export default defineComponent({
  components: {
    InputField,
  },
  setup() {
    const increment = () => {
      console.log("zidan");
    };

    return {
      increment,
    };
  },
});
</script>

<template>
  <div>
    <InputField>kokot</InputField>
  </div>
</template>

<style scoped lang="scss">
</style>
