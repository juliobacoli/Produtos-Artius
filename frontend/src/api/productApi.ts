// src/api/productApi.ts
import { api } from "./client";

function unwrap(data: any) {
  // Suporta ApiResponse<T> (Dados/dados) e retorno “cru”
  if (data?.dados !== undefined) return data.dados;
  if (data?.Dados !== undefined) return data.Dados;
  return data;
}

export async function getProducts() {
  const res = await api.get("/produto");
  return unwrap(res.data);
}

export async function createProduct(payload: { nome: string; preco: number; categoria: string }) {
  const res = await api.post("/produto", payload);
  return unwrap(res.data);
}
