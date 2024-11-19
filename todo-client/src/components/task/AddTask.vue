<template>
  <div class="add-task">
    <h2>{{ isEditMode ? "Edit Task" : "Add New Task" }}</h2>
    <form @submit.prevent="submitTask">
      <InputField v-model="taskData.title" label="Title" required />
      <InputField
        v-model="taskData.content"
        label="Content"
        textarea
        required
      />
      <div class="state-select">
        <label>State:</label>
        <select v-model="taskData.state" :disabled="!isEditMode">
          <option :value="TaskState.Open">Open</option>
          <option :value="TaskState.InProgress">In Progress</option>
          <option :value="TaskState.Finished">Finished</option>
        </select>
      </div>
      <div class="buttons">
      
        <Button v-if="isEditMode !== true" type="submit">Save Task</Button>
        <Button v-if="isEditMode === true" type="submit" @click="submitTask"
          >Save Changes</Button
        >
        <Button @click="$emit('cancel')">Cancel</Button>
      </div>
    </form>
  </div>
</template>

<script>
import InputField from "../ui/InputField.vue";
import Button from "../ui/Button.vue";
import { TaskDTO, TaskState } from "../../dto/TaskDto";
import axios from "axios";

export default {
  name: "AddTask",
  components: {
    InputField,
    Button,
  },
  props: {
    task: Object,
  },
  emits: ["task-saved", "task-updated", "cancel", "close-modal"],
  data() {
    return {
      taskData: new TaskDTO(),
      TaskState,
    };
  },
  computed: {
    isEditMode() {
      return !!this.task;
    },
  },
  methods: {
    async submitTask() {
      if (this.isEditMode) {
        await this.editTask();
      } else {
        await this.createTask();
      }
      this.$emit("close-modal");
    },
    async createTask() {
      try {
        const requestData = {
          id: "",
          title: this.taskData.title,
          state: this.taskData.state,
          content: this.taskData.content,
        };

        const response = await axios.post(
          "https://localhost:7288/Todo",
          requestData
        );

        const tasks = JSON.parse(localStorage.getItem("tasks")) || [];
        tasks.push(response.data);
        localStorage.setItem("tasks", JSON.stringify(tasks));

        this.$emit("task-saved", response.data);
        this.taskData = new TaskDTO();
      } catch (error) {
        console.error(
          "Error creating task:",
          error.response ? error.response.data : error.message
        );
      }
    },

    async editTask() {
      try {
        const updatedTask = {
          id: this.taskData.id,
          title: this.taskData.title,
          content: this.taskData.content,
          state: this.taskData.state,
        };

        const response = await axios.put(
          `https://localhost:7288/Todo/${this.taskData.id}`,
          updatedTask
        );

        const tasks = JSON.parse(localStorage.getItem("tasks")) || [];
        const taskIndex = tasks.findIndex((task) => task.id === updatedTask.id);
        if (taskIndex !== -1) {
          tasks[taskIndex] = updatedTask;
          localStorage.setItem("tasks", JSON.stringify(tasks));
        }

        this.$emit("task-updated", response.data);
        this.$store.commit("UPDATE_TASK", response.data);
      } catch (error) {
        console.error(
          "Error updating task:",
          error.response?.data || error.message
        );
      }
    },
  },
  created() {
    if (this.isEditMode && this.task) {
      this.taskData = {
        id: this.task.id,
        title: this.task.title,
        content: this.task.content,
        state: this.task.state,
      };
    }
  },
};
</script>

<style scoped lang="scss">
@import "../../colors.scss";

.add-task {
  background-color: $secondary-color;

  h2 {
    margin-bottom: 5px;
  }
  form {
    display: flex;
    flex-direction: column;

    .state-select {
      margin-bottom: 10px;
      label {
        margin-right: 10px;
      }
    }
    .buttons {
      display: flex;
      justify-content: flex-end;
      margin-top: 15px;
      Button {
        margin-left: 10px;
        background-color: $task-card-color;
      }
      Button:hover {
        background-color: #09858c;
        transition: background-color 0.3s ease;
      }
    }
  }
}
</style>
