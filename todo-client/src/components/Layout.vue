<template>
  <div class="layout">
    <div class="add-task-button">
      <Button @click="openAddModal">Add Task</Button>
    </div>
    <TaskList
      :tasks="tasks"
      @edit-task="openEditModal"
      @delete-task="deleteTask"
    />
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
import AddTask from './task/AddTask.vue';
import TaskList from './task/TaskList.vue';
import Modal from './ui/Modal.vue';
import Button from './ui/Button.vue';
import { v4 as uuidv4 } from 'uuid';

export default {
  name: 'Layout',
  components: {
    AddTask,
    TaskList,
    Modal,
    Button,
  },
  data() {
    return {
      tasks: [],
      showModal: {
        visible: false,
        mode: '',
      },
      currentTask: null,
    };
  },
  methods: {
    openAddModal() {
      this.currentTask = null;
      this.showModal = { visible: true, mode: 'add' };
    },
    openEditModal(task) {
      this.currentTask = { ...task };
      this.showModal = { visible: true, mode: 'edit' };
    },
    closeModal() {
      this.showModal = { visible: false, mode: '' };
      this.currentTask = null;
    },
    saveTask(task) {
      if (this.showModal.mode === 'add') {
        task.id = uuidv4();
        this.tasks.push(task);
      } else if (this.showModal.mode === 'edit') {
        const index = this.tasks.findIndex((t) => t.id === task.id);
        if (index !== -1) {
          this.tasks.splice(index, 1, task);
        }
      }
      this.saveTasks();
      this.closeModal();
    },
    deleteTask(taskId) {
      this.tasks = this.tasks.filter((task) => task.id !== taskId);
      this.saveTasks();
    },
    saveTasks() {
      localStorage.setItem('tasks', JSON.stringify(this.tasks));
    },
  },
  created() {
    const savedTasks = localStorage.getItem('tasks');
    if (savedTasks) {
      this.tasks = JSON.parse(savedTasks);
    }
  },
};
</script>

<style scoped lang="scss">
.layout {
  width: 100%;
  max-width: 800px;
  .add-task-button {
    margin-bottom: 20px;
    display: flex;
    justify-content: flex-end;
  }
}
</style>
