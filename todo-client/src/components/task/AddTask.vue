<template>
  <div class="add-task">
    <h2>{{ isEditMode ? "Edit Task" : "Add New Task" }}</h2>
    <form @submit.prevent="submitTask">
      <InputField v-model="taskData.title" label="Title" required />
      <InputField
        v-model="taskData.description"
        label="Description"
        textarea
        required
      />
      <div class="state-select">
        <label>State:</label>
        <select v-model="taskData.state">
          <option value="open">Open</option>
          <option value="in progress">In Progress</option>
          <option value="finished">Finished</option>
        </select>
      </div>
      <div class="buttons">
        <Button type="submit">{{
          isEditMode ? "Save Changes" : "Save Task"
        }}</Button>
        <Button @click="$emit('cancel')">Cancel</Button>
      </div>
    </form>
  </div>
</template>

<script>
import InputField from "../ui/InputField.vue";
import Button from "../ui/Button.vue";

export default {
  name: "AddTask",
  components: {
    InputField,
    Button,
  },
  props: {
    task: Object,
  },
  emits: ["task-saved", "cancel"],
  data() {
    return {
      taskData: {
        title: "",
        description: "",
        state: "open",
        id: null,
      },
    };
  },
  computed: {
    isEditMode() {
      return !!this.task;
    },
  },
  methods: {
    submitTask() {
      this.$emit("task-saved", { ...this.taskData });
      if (!this.isEditMode) {
        this.taskData = {
          title: "",
          description: "",
          state: "open",
          id: null,
        };
      }
    },
  },
  created() {
    if (this.isEditMode) {
      this.taskData = { ...this.task };
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
