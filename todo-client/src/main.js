import { createApp } from "vue";
import App from "./App.vue";
import store from "./state/store";

createApp(App).use(store).mount("#app");
