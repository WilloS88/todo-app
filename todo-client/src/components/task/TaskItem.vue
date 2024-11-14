<template>
  <div class="task-item">
    <h3>{{ task.title }}</h3>
    <div>{{ task.description }}</div>
    <p><strong>State:</strong> {{ task.state }}</p>
    <div class="buttons">
      <Button @click="editTask" class="edit-task-button">Edit Task</Button>
      <Button @click="confirmDelete" class="delete-task-button">
        <img :src="BinIcon" class="bin-icon" />
      </Button>
    </div>
  </div>
</template>

<script>
import Button from "../ui/Button.vue";
import { mapActions } from "vuex";
import BinIcon from "../../assets/BinIcon.svg";

export default {
  name: "TaskItem",
  components: {
    Button,
  },
  data() {
    return {
      BinIcon,
    };
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
@import "../../colors.scss";

.task-item {
  font-family: Arial, Helvetica, sans-serif;
  display: flex;
  flex-direction: column;
  gap: 7px;
  background-color: $task-card-color;
  border: 3px solid #ccc;
  border-radius: 5px;
  padding: 15px;
  margin-bottom: 10px;
  width: 50%;
  max-width: 500px;
  h3 {
    margin-top: 0;
    overflow-wrap: break-word;
  }
  div {
    overflow-wrap: break-word;
  }
  .buttons {
    margin-top: 10px;
    display: flex;
    gap: 20px;
    .edit-task-button {
      background-color: $primary-color;
      color: white;
      font-weight: 600;
    }
    .edit-task-button:hover {
      background-color: $secondary-color;
      transition: background-color 0.3s ease;
    }
    .delete-task-button {
      background-color: $primary-color;
    }
    .delete-task-button:hover {
      background-color: $secondary-color;
      transition: background-color 0.3s ease;
    }
  }
  .bin-icon {
    color: white;
    width: 20px;
  }
}
</style>
