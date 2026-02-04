import axios from "axios";

export interface Record {
  id?: string;
  name: string;
  surname: string;
  age: number;
  email: string;
  phoneNumber: string;
}

const entityApi = axios.create({
  baseURL: "http://localhost:8080/api",
  headers: {
    "Content-Type": "application/json",
  },
});

const webServiceApi = axios.create({
  baseURL: "http://localhost:8082/api",
  headers: {
    "Content-Type": "application/json",
  },
});

export const recordService = {
  async addRecord(record: Omit<Record, "id">) {
    const response = await entityApi.post("/entity/add", record);
    return response.data;
  },

  async deleteRecord(name: string) {
    const response = await entityApi.delete(`/entity/delete/${encodeURIComponent(name)}`);
    return response.data;
  },

  async getAllRecords() {
    const response = await entityApi.get("/entity/list");
    return response.data;
  },

  async searchRecords(name: string) {
    const response = await entityApi.get(`/entity/search/${encodeURIComponent(name)}`);
    return response.data;
  },
};

export const webService = {
  async addRecord(record: Omit<Record, "id">) {
    const response = await webServiceApi.post("/entity/add", record);
    return response.data;
  },

  async deleteRecord(name: string) {
    const response = await webServiceApi.delete(`/entity/delete/${encodeURIComponent(name)}`);
    return response.data;
  },

  async getAllRecords() {
    const response = await webServiceApi.get("/entity/list");
    return response.data;
  },

  async searchRecords(name: string) {
    const response = await webServiceApi.get(`/entity/search/${encodeURIComponent(name)}`);
    return response.data;
  },
};

export default entityApi;
