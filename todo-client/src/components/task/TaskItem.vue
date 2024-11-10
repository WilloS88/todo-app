<!-- src/components/task/TaskItem.vue -->
<template>
  <div class="task-item">
    <h3>{{ task.title }}</h3>
    <p>{{ task.description }}</p>
    <p><strong>State:</strong> {{ task.state }}</p>
    <div class="buttons">
      <Button @click="editTask">Edit Task</Button>
      <Button @click="confirmDelete">Delete Task</Button>
    </div>
  </div>
</template>

<script>
import Button from '../ui/Button.vue';

export default {
  name: 'TaskItem',
  components: {
    Button,
  },
  props: {
    task: Object,
  },
  emits: ['edit-task', 'delete-task'],
  methods: {
    editTask() {
      this.$emit('edit-task', this.task);
    },
    confirmDelete() {
      if (confirm('Are you sure you want to delete this task?')) {
        this.$emit('delete-task', this.task.id);
      }
    },
  },
};
</script>

<style scoped lang="scss">
.task-item {
  border: 1px solid #ccc;
  padding: 15px;
  margin-bottom: 10px;
  h3 {
    margin-top: 0;
  }
  .buttons {
    margin-top: 10px;
    Button {
      margin-right: 10px;
    }
  }
}
</style>
