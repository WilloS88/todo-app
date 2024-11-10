<template>
  <div class="task-list">
    <h2>Task List</h2>
    <div v-if="tasks.length">
      <TaskItem
        v-for="task in tasks"
        :key="task.id"
        :task="task"
        @edit-task="$emit('edit-task', $event)"
        @delete-task="$emit('delete-task', $event)"
      />
    </div>
    <div v-else>
      <p>No tasks available.</p>
    </div>
  </div>
</template>

<script>
import TaskItem from './TaskItem.vue';

export default {
  name: 'TaskList',
  components: {
    TaskItem,
  },
  props: {
    tasks: Array,
  },
};
</script>

<style scoped lang="scss">
.task-list {
  margin-top: 20px;
}
</style>
