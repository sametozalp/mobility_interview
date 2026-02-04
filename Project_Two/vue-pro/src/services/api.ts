import axios from "axios";

const API_BASE_URL = "http://localhost:5000/api";

const api = axios.create({
  baseURL: API_BASE_URL,
});

export interface Record {
  id?: number;
  name: string;
  surname: string;
  age: number;
  email: string;
  PhoneNumber: string;
}

export const recordService = {
  async addRecord(record: Omit<Record, "id">) {
    const formData = new FormData();
    formData.append("Name", record.name);
    formData.append("Surname", record.surname);
    formData.append("Age", String(record.age));
    formData.append("Email", record.email);
    formData.append("PhoneNumber", record.PhoneNumber);

    const response = await api.post("/entity/add", formData);
    return response.data;
  },

  async deleteRecord(name: string) {
    const response = await api.delete(`/entity/delete/${encodeURIComponent(name)}`);
    return response.data;
  },

  async getAllRecords() {
    const response = await api.get("/entity/list");
    return response.data;
  },

  async searchRecords(name: string) {
    const response = await api.get(`/entity/search/${encodeURIComponent(name)}`);
    return response.data;
  },
};

export const webService = {
  async addRecord(record: Omit<Record, "id">) {
    const formData = new FormData();
    formData.append("Name", record.name);
    formData.append("Surname", record.surname);
    formData.append("Age", String(record.age));
    formData.append("Email", record.email);
    formData.append("PhoneNumber", record.PhoneNumber);

    const response = await api.post("/weboperation/add", formData);
    return response.data;
  },

  async deleteRecord(name: string) {
    const response = await api.delete(`/weboperation/delete/${encodeURIComponent(name)}`);
    return response.data;
  },

  async getAllRecords() {
    const response = await api.get("/weboperation/list");
    return response.data;
  },

  async searchRecords(name: string) {
    const response = await api.get(`/weboperation/search/${encodeURIComponent(name)}`);
    return response.data;
  },
};

export default api;
