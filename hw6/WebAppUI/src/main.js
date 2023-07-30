import "./style.css";

const API_URL = "https://localhost:7263";
const OFFSET_JSON = 2;

const getAllUsersBtn = document.querySelector("#btn-get-all");
const getUserBtn = document.querySelector("#btn-get");
const createUserBtn = document.querySelector("#btn-post");
const deleteUserBtn = document.querySelector("#btn-delete");
const updateUserBtn = document.querySelector("#btn-put");

const getUserIdInput = document.querySelector("#input-get");
const deleteUserIdInput = document.querySelector("#input-delete");
const updateUserIdInput = document.querySelector("#input-put");

const createUserInput = document.querySelector("#textarea-post");
const updateUserInput = document.querySelector("#textarea-put");

const getAllUsersResponseTextarea = document.querySelector("#textarea-response-get-all");
const getUserResponseTextarea = document.querySelector("#textarea-response-get");
const createUserResponseTextarea = document.querySelector("#textarea-response-post");
const deleteUserResponseTextarea = document.querySelector("#textarea-response-delete");
const updateUserResponseTextarea = document.querySelector("#textarea-response-put");

const getAllUsers = async () => {
  const response = await fetch(`${API_URL}/users`);

  return response.json();
};

const getUserById = async id => {
  const response = await fetch(`${API_URL}/users/${id}`);

  return response.json();
};

const createUser = async user => {
  const options = {
    body: JSON.stringify(user),
    headers: {
      "Content-Type": "application/json",
    },
    method: "POST",
  };

  const response = await fetch(`${API_URL}/users`, options);

  return response.json();
};

const deleteUser = async id => {
  const options = {
    method: "DELETE",
  };

  const response = await fetch(`${API_URL}/users/${id}`, options);

  return response.json();
};

const updateUser = async (userId, updatedUser) => {
  const options = {
    body: JSON.stringify(updatedUser),
    headers: {
      "Content-Type": "application/json",
    },
    method: "PUT",
  };

  const response = await fetch(`${API_URL}/users/${userId}`, options);

  return response.json();
};

const handleGetAllUsers = async () => {
  const allUsers = await getAllUsers();

  getAllUsersResponseTextarea.value = "";
  getAllUsersResponseTextarea.value = JSON.stringify(allUsers, null, OFFSET_JSON);
};

const handleGetUser = async () => {
  const userId = getUserIdInput.value;
  const response = await getUserById(userId);

  getUserResponseTextarea.value = "";
  getUserResponseTextarea.value = JSON.stringify(response, null, OFFSET_JSON);
};

const handleCreateUser = async () => {
  const newUser = createUserInput.value;
  const parsedJSON = JSON.parse(newUser);

  const response = await createUser(parsedJSON);

  createUserResponseTextarea.value = "";
  createUserResponseTextarea.value = JSON.stringify(response, null, OFFSET_JSON);
};

const handleDeleteUser = async () => {
  const userId = deleteUserIdInput.value;

  const response = await deleteUser(userId);

  deleteUserResponseTextarea.value = "";
  deleteUserResponseTextarea.value = JSON.stringify(response, null, OFFSET_JSON);
};

const handleUpdateUser = async () => {
  const userId = updateUserIdInput.value;

  const updatedUser = updateUserInput.value;
  const parsedJSON = JSON.parse(updatedUser);

  const response = await updateUser(userId, parsedJSON);

  updateUserResponseTextarea.value = "";
  updateUserResponseTextarea.value = JSON.stringify(response, null, OFFSET_JSON);
};

getAllUsersBtn.addEventListener("click", handleGetAllUsers);
getUserBtn.addEventListener("click", handleGetUser);
createUserBtn.addEventListener("click", handleCreateUser);
deleteUserBtn.addEventListener("click", handleDeleteUser);
updateUserBtn.addEventListener("click", handleUpdateUser);
