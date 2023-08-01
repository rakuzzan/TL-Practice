import "./style.css";

const API_URL = "https://localhost:7263";
const JSON_OFFSET = 2;

const getAllUsers = async() => {
  try {
    const response = await fetch(`${API_URL}/users`);
    const data = await response.json();
    document.getElementById("textarea-response-get-all").textContent = JSON.stringify(data, null, JSON_OFFSET);
  } catch (error) {
    console.error("Ошибка при получении списка пользователей:", error);
  }
}
document.getElementById("btn-get-all").addEventListener("click", getAllUsers);

const getUser = async() => {
  const userId = document.getElementById("input-get").value;
  try {
    const response = await fetch(`${API_URL}/users/${userId}`);
    const data = await response.json();
    document.getElementById("textarea-response-get").textContent = JSON.stringify(data, null, JSON_OFFSET);
  } catch (error) {
    console.error("Ошибка при получении пользователя:", error);
  }
}
document.getElementById("btn-get").addEventListener("click", getUser);

const createUser = async() => {
  const userData = document.getElementById("input-post").value.trim();
  try {
    const response = await fetch(`${API_URL}/users`, {
      body: userData,
      headers: {
        "Content-Type": "application/json",
      },
      method: "POST",
    });
    const data = await response.json();
    document.getElementById("textarea-response-post").textContent = JSON.stringify(data, null, JSON_OFFSET);
  } catch (error) {
    console.error("Ошибка при добавлении пользователя:", error);
  }
}
document.getElementById("btn-post").addEventListener("click", createUser);


const updateUser = async() => {
  const userId = document.getElementById("input-put").value;
  const userData = document.getElementById("textarea-put").value.trim();
  try {
    const response = await fetch(`${API_URL}/users/${userId}`, {
      body: userData,
      headers: {
        "Content-Type": "application/json",
      },
      method: "PUT",
    });
    const data = await response.json();
    document.getElementById("textarea-response-put").textContent = JSON.stringify(data, null, JSON_OFFSET);
  } catch (error) {
    console.error("Ошибка при обновлении данных пользователя:", error);
  }
}
document.getElementById("btn-put").addEventListener("click", updateUser);


const deleteUser = async () => {
  const userId = document.getElementById("input-delete").value;
  try {
    const response = await fetch(`${API_URL}/users/${userId}`, {
      method: "DELETE",
    });
    const data = await response.json();
    document.getElementById("textarea-response-delete").textContent = JSON.stringify(data, null, JSON_OFFSET);
  } catch (error) {
    console.error("Ошибка при удалении пользователя:", error);
  }
}
document.getElementById("btn-delete").addEventListener("click", deleteUser);
