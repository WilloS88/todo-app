<template>
  <div class="task-card">
    <h3>{{ task.title }}</h3>
    <div>{{ task.description }}</div>
    <button @click="toggleComplete">
      {{ task.completed ? "Undo" : "Complete" }}
    </button>
  </div>
</template>

<script>
import { defineComponent, ref, toRefs } from "vue";
import PageCard from "./PageCard.vue";

export default defineComponent({
  components: {
    PageCard,
  },
  props: {
    task: {
      type: Object,
      required: true,
      default: () => ({
        title: "",
        description: "",
        completed: false,
      }),
    },
  },
  setup(props) {
    const { task } = toRefs(props);
    const toggleComplete = () => {
      task.value.completed = !task.value.completed;
    };

    return {
      task,
      toggleComplete,
    };
  },
});
</script>

<style scoped lang="scss">
.task-card {
  border: 1px solid #ccc;
  padding: 16px;
  margin: 8px;
  border-radius: 4px;
  max-width: 300px;
}

.task-card h3,
.task-card div {
  overflow-wrap: break-word;
}

.task-card div {
  width: auto;
}
</style>
