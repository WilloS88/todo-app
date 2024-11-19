export class TaskState {
  static Open = "Open";
  static InProgress = "InProgress";
  static Finished = "Finished";
}

export class TaskDTO {
  constructor(id = "", title = "",  content = "", state = TaskState.InProgress) {
    this.id = id;
    this.title = title;
    this.content = content;
    this.state = state;
  }

  updateState(newState) {
    if (Object.values(TaskState).includes(newState)) {
      this.state = newState;
    } else {
      console.error("Invalid state");
    }
  }
}
