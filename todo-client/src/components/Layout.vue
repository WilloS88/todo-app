<template>
  <div class="layout">
    <div class="add-task-div">
      <div class="add-task-div-header">Task List</div>
      <Button @click="openAddModal" class="add-task-div-button">
        Add Task
      </Button>
    </div>
    <div>
      <TaskList @edit-task="openEditModal" />
      <Modal v-if="showModal.visible" @close="closeModal">
        <AddTask
          :task="currentTask"
          @task-saved="saveTask"
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
    font-size: 20px;
    font-weight: 700;
    padding: 20px;
    background-color: $primary-color;
  }
  .add-task-div-button:hover {
    background-color: $secondary-color;
    transition: background-color 0.3s ease;
  }
}
</style>
