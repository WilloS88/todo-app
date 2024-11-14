<template>
  <div>
    <button @click="fetchData">Fetch Data test</button>

    <div v-if="result">
      <pre>{{ result }}</pre>
    </div>
    <div v-else-if="error">
      <p>Error: {{ error }}</p>
    </div>
  </div>
</template>

<script>
import axios from "axios";
import { ref } from "vue";

export default {
  name: "FetchDataButton",
  setup() {
    const result = ref(null);
    const error = ref(null);

    const fetchData = async () => {
      try {
        const response = await axios.get("https://localhost:7288/test");
        result.value = response.data;
        error.value = null;

        console.log(result.value);
      } catch (err) {
        error.value = "Error fetching data";
        console.error(err);
      }
    };

    return {
      fetchData,
      result,
      error,
    };
  },
};
</script>

<style scoped>
button {
  padding: 10px 20px;
  font-size: 16px;
}
</style>
