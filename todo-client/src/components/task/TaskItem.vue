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
import Button from "../ui/Button.vue";
import { mapActions } from "vuex";

export default {
  name: "TaskItem",
  components: {
    Button,
  },
  props: {
    task: Object,
  },
  methods: {
    editTask() {
      this.$emit("edit-task", this.task);
    },
    confirmDelete() {
      this.deleteTask(this.task.id);
    },
    ...mapActions(["deleteTask"]),
  },
};
</script>

<style scoped lang="scss">
.task-item {
  font-family: Arial, Helvetica, sans-serif;
  background-color: rgb(243, 243, 243);
  border: 1px solid #ccc;
  border-radius: 5px;
  padding: 15px;
  margin-bottom: 10px;
  width: 80%;
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
