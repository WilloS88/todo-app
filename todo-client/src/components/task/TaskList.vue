<template>
  <div class="task-list">
    <h2>Task List</h2>
    <div v-if="tasks.length">
      <TaskItem
        v-for="task in tasks"
        :key="task.id"
        :task="task"
        @edit-task="openEditModal"
        @delete-task="deleteTask"
      />
    </div>
    <div v-else>
      <p>No tasks available.</p>
    </div>
  </div>
</template>

<script>
import TaskItem from "./TaskItem.vue";
import { mapState, mapActions } from "vuex";

export default {
  name: "TaskList",
  components: {
    TaskItem,
  },
  computed: {
    ...mapState({
      tasks: (state) => state.tasks,
    }),
  },
  methods: {
    ...mapActions(["deleteTask"]),
    openEditModal(task) {
      this.$emit("edit-task", task);
    },
  },
};
</script>

<style scoped lang="scss">
.task-list {
  margin-top: 20px;
  min-width: 80%;
}
</style>
