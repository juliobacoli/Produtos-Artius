import axios from "axios";

/**
 * Forçar a URL da sua API aqui.
 * Se der problema com HTTPS/certificado, troque para http://localhost:5096
 */
const BASE_URL = "https://localhost:7290"; // <- AJUSTE AQUI SE PRECISAR

export const api = axios.create({
  baseURL: BASE_URL,
  headers: { "Content-Type": "application/json" },
  timeout: 10000,
});
