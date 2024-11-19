<template>
  <div class="task-list">
    <div v-if="tasks.length" class="task-list-item">
      <TaskItem
        v-for="task in tasks"
        :key="task.id"
        :task="task"
        @edit-task="openEditModal"
        @delete-task="deleteTask"
      />
    </div>
    <div v-else>
      <p class="no-tasks-message">No tasks available.</p>
    </div>
  </div>
</template>

<script>
import TaskItem from "./TaskItem.vue";
import { mapState, mapActions } from "vuex";
import axios from "axios";

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
  mounted() {
    axios
      .get("https://localhost:7288/Todo")
      .then((response) => {
        this.todos = response.data;
        localStorage.setItem("tasks", JSON.stringify(this.todos));
      })
      .catch((error) => {
        console.error("Error fetching the todo data:", error);
      });
  },
};
</script>

<style scoped lang="scss">
.task-list {
  margin-top: 20px;
  min-width: 800px;
}

.task-list-item {
  display: flex;
  flex-direction: column;
  align-items: center;
}

.no-tasks-message {
  font-family: "Courier New", Courier, monospace;
  color: white;
  text-align: center;
}
</style>
