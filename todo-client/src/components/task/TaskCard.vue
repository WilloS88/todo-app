<script>
import { defineComponent, ref, toRefs } from 'vue';
import PageCard from "./PageCard.vue"

export default defineComponent({
  components: {
    PageCard,
  },
  props: {
    task: {
      type: Object,
      required: true,
      default: () => ({
        title: '',
        description: '',
        completed: false
      })
    }
  },
  setup(props) {
    const { task } = toRefs(props);
    const toggleComplete = () => {
      task.value.completed = !task.value.completed;
    };

    return {
      task,
      toggleComplete
    };
  }
});
</script>

<template>
  <PageCard>
  <div class="task-card">
    <h3>{{ task.title }}</h3>
    <p>{{ task.description }}</p>
    <button @click="toggleComplete">{{ task.completed ? 'Undo' : 'Complete' }}</button>
  </div>
  </PageCard>
</template>

<style scoped lang="scss">
.task-card {
  border: 1px solid #ccc;
  padding: 16px;
  margin: 8px;
  border-radius: 4px;
}
</style></template>