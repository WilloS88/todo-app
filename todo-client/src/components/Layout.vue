<template>
  <div class="layout">
    <div class="add-task-div">
      <div class="add-task-div-header">Task List</div>
      <Button @click="openAddModal" class="add-task-div-button">
        Add task
      </Button>
    </div>
    <div>
      <TaskList @edit-task="openEditModal" />
      <Modal v-if="showModal.visible" @close="closeModal">
        <AddTask
          v-if="showModal"
          :task="currentTask"
          @task-saved="refreshTasks"
          @task-updated="refreshTasks"
          @close-modal="closeModal"
          @cancel="closeModal"
        />
      </Modal>
    </div>
  </div>
</template>

<script>
import AddTask from "./task/AddTask.vue";
import TaskList from "./task/TaskList.vue";
import Modal from "./ui/Modal.vue";
import Button from "./ui/Button.vue";
import { mapActions } from "vuex";

export default {
  name: "Layout",
  components: {
    AddTask,
    TaskList,
    Modal,
    Button,
  },
  data() {
    return {
      showModal: {
        visible: false,
        mode: "",
      },
      currentTask: null,
    };
  },
  methods: {
    ...mapActions(["addTask", "updateTask", "loadTasks"]),
    openAddModal() {
      this.currentTask = null;
      this.showModal = { visible: true, mode: "add" };
    },
    openEditModal(task) {
      this.currentTask = { ...task };
      this.showModal = { visible: true, mode: "edit" };
    },
    closeModal() {
      this.showModal = { visible: false, mode: "" };
      this.currentTask = null;
    },
    saveTask(task) {
      if (this.showModal.mode === "add") {
        this.addTask(task);
      } else if (this.showModal.mode === "edit") {
        this.updateTask(task);
      }
      this.closeModal();
    },
    refreshTasks() {
      const storedTasks = JSON.parse(localStorage.getItem("tasks")) || [];
      this.$store.commit("SET_TASKS", storedTasks);
    },
  },
  created() {
    this.loadTasks();
  },
};
</script>

<style scoped lang="scss">
@import "../colors.scss";

.layout {
  display: flex;
  flex-direction: column;

  width: 100%;
  margin: 30px 0px 30px 0px;

  .add-task-div {
    margin-bottom: 20px;
    display: flex;
    justify-content: space-around;

    .add-task-div-header {
      font-family: "Courier New", Courier, monospace;
      color: white;
      font-size: 30px;
      font-weight: 800;
      text-align: center;
      align-self: center;
    }
  }

  .add-task-div-button {
    font-family: "Courier New", Courier, monospace;
    font-weight: bold;
    letter-spacing: 0.025em;
    border-radius: 0.5rem;
    transition: background-color 300ms, box-shadow 300ms, color 300ms;
    padding: 0.75rem 2rem;
    font-size: 1.125rem;
    background-color: $primary-color;
    box-shadow: 0 4px 6px -1px $primary-color,
      0 2px 4px -2px rgba(37, 99, 235, 0.2);

    &:hover {
      background-color: $secondary-color;
      box-shadow: 0 4px 6px -1px $secondary-color,
        0 2px 4px -2px $secondary-color;
      color: #ffffff;
    }
  }
}
</style>
