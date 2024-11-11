<template>
  <div class="layout">
    <div class="add-task-div">
      <Button @click="openAddModal">Add Task</Button>
    </div>
    <TaskList @edit-task="openEditModal" />
    <Modal v-if="showModal.visible" @close="closeModal">
      <AddTask
        :task="currentTask"
        @task-saved="saveTask"
        @cancel="closeModal"
      />
    </Modal>
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
.layout {
  width: 100%;
  max-width: 800px;
  margin: 30px 0px 30px 0px;

  .add-task-div {
    margin-bottom: 20px;
    display: flex;
    justify-content: center;
  }
}
</style>
