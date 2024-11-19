import { createStore } from "vuex";
import { v4 as uuidv4 } from "uuid";

export default createStore({
  state: {
    tasks: [],
  },
  mutations: {
    SET_TASKS(state, tasks) {
      state.tasks = tasks;
    },
    UPDATE_TASK(state, updatedTask) {
      const index = state.tasks.findIndex((t) => t.id === updatedTask.id);
      if (index !== -1) {
        state.tasks.splice(index, 1, updatedTask);
      }
    },
    ADD_TASK(state, task) {
      state.tasks.push(task);
    },
    DELETE_TASK(state, taskId) {
      state.tasks = state.tasks.filter((task) => task.id !== taskId);
    },
  },
  actions: {
    loadTasks({ commit }) {
      const savedTasks = localStorage.getItem("tasks");
      if (savedTasks) {
        commit("SET_TASKS", JSON.parse(savedTasks));
      }
    },
    saveTasks({ state }) {
      localStorage.setItem("tasks", JSON.stringify(state.tasks));
    },
    addTask({ commit, dispatch }, task) {
      task.id = uuidv4();
      commit("ADD_TASK", task);
      dispatch("saveTasks");
    },
    updateTask({ commit, dispatch }, updatedTask) {
      commit("UPDATE_TASK", updatedTask);
      dispatch("saveTasks");
    },
    deleteTask({ commit, dispatch }, taskId) {
      commit("DELETE_TASK", taskId);
      dispatch("saveTasks");
    },
  },
  getters: {
    allTasks(state) {
      return state.tasks;
    },
  },
});
