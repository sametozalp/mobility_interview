import axios from "axios";
import { toast } from "react-toastify";

const webApi = axios.create({
  baseURL: "http://localhost:8082/api",
  headers: {
    "Content-Type": "application/json",
  },
});

webApi.interceptors.response.use(
  (response) => {
    return response;
  },
  (error) => {
    const message = error?.message || "Error!";
    toast.error(message);
    return Promise.reject(error);
  }
);

export default class WebService {

  async addRecord(record) {
    const response = await webApi.post("/webService/add", record);
    return response.data;
  }

  async deleteRecord(name) {
    const response = await webApi.delete(`/webService/delete/${encodeURIComponent(name)}`);
    return response.data;
  }

  async getAllRecords() {
    const response = await webApi.get("/webService/list");
    return response.data;
  }

  async searchRecords(name) {
    const response = await webApi.get(`/webService/search/${encodeURIComponent(name)}`);
    return response.data;
  }
}