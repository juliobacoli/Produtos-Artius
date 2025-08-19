import { useEffect, useState } from "react";
import { getProducts, createProduct } from "./api/productApi";

type Produto = {
  id?: string; Id?: string;
  nome?: string; Nome?: string;
  preco?: number; Preco?: number;
  categoria?: string; Categoria?: string;
};

export default function App() {
  const [items, setItems] = useState<Produto[]>([]);
  const [form, setForm] = useState({ nome: "", preco: "", categoria: "" });
  const [loading, setLoading] = useState(true);
  const [err, setErr] = useState("");

  async function load() {
    setErr(""); setLoading(true);
    try {
      const data = await getProducts();
      setItems(Array.isArray(data) ? data : []);
    } catch (e: any) {
      setErr(e?.response?.data?.error ?? "Falha ao carregar produtos");
    } finally { setLoading(false); }
  }

  useEffect(() => { load(); }, []);

  async function onSubmit(e: React.FormEvent) {
    e.preventDefault();
    setErr("");
    try {
      await createProduct({
        nome: form.nome.trim(),
        preco: Number(form.preco),
        categoria: form.categoria.trim(),
      });
      setForm({ nome: "", preco: "", categoria: "" });
      await load();
    } catch (e: any) {
      setErr(e?.response?.data?.error ?? "Falha ao criar produto");
    }
  }

  return (
    <div style={{ padding: 24, display: "grid", gap: 24, color: "#fff" }}>
      <h1>Produtos</h1>

      <form onSubmit={onSubmit} style={{ display: "grid", gap: 12, maxWidth: 420 }}>
        <input
          placeholder="Nome" value={form.nome}
          onChange={e => setForm(f => ({ ...f, nome: e.target.value }))} required
        />
        <input
          placeholder="Preço" type="number" step="0.01" value={form.preco}
          onChange={e => setForm(f => ({ ...f, preco: e.target.value }))} required
        />
        <input
          placeholder="Categoria" value={form.categoria}
          onChange={e => setForm(f => ({ ...f, categoria: e.target.value }))} required
        />
        <button type="submit">Cadastrar</button>
      </form>

      {loading ? <p>Carregando...</p> : (
        items.length ? (
          <table border={1} cellPadding={8} style={{ borderCollapse:"collapse", width:"100%", maxWidth: 720 }}>
            <thead><tr><th>Id</th><th>Nome</th><th>Preço</th><th>Categoria</th></tr></thead>
            <tbody>
              {items.map((p, i) => {
                const id = p.id ?? p.Id;
                const nome = p.nome ?? p.Nome;
                const preco = p.preco ?? p.Preco;
                const cat = p.categoria ?? p.Categoria;
                return (
                  <tr key={id ?? i}>
                    <td>{id}</td>
                    <td>{nome}</td>
                    <td>{Number(preco).toLocaleString("pt-BR",{style:"currency",currency:"BRL"})}</td>
                    <td>{cat}</td>
                  </tr>
                );
              })}
            </tbody>
          </table>
        ) : <p>Nenhum produto.</p>
      )}

      {err && <small style={{ color: "crimson" }}>{err}</small>}
    </div>
  );
}
