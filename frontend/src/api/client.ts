import axios from "axios";

const BASE_URL = "https://localhost:7290";

export const api = axios.create({
  baseURL: BASE_URL,
  headers: { "Content-Type": "application/json" },
  timeout: 10000,
});
