<script setup lang="ts">
import { onMounted, ref } from "vue";
import { webService, type Record } from "../../services/api";

const records = ref<Record[]>([]);
const isLoading = ref(false);
const message = ref("");
const messageType = ref<"success" | "error" | "">("");

const showMessage = (msg: string, type: "success" | "error") => {
  message.value = msg;
  messageType.value = type;
  setTimeout(() => {
    message.value = "";
    messageType.value = "";
  }, 3000);
};

const loadRecords = async () => {
  isLoading.value = true;
  try {
    const data = await webService.getAllRecords();
    records.value = data;
    if (data.length === 0) {
      showMessage("No records found via Web Service", "error");
    } else {
      showMessage(`Loaded ${data.length} records via Web Service`, "success");
    }
  } catch (error) {
    console.error("Error loading records via web service:", error);
    showMessage("Failed to load records via Web Service. Please try again.", "error");
  } finally {
    isLoading.value = false;
  }
};

onMounted(() => {
  loadRecords();
});
</script>

<template>
  <div class="list-records-container">
    <div class="list-card">
      <div class="list-header">
        <h1>List Records - Web Service Operations</h1>
        <button @click="loadRecords" class="btn" :disabled="isLoading">
          {{ isLoading ? "Loading via Web Service..." : "Refresh via Web Service" }}
        </button>
      </div>

      <div v-if="message" :class="['message', messageType]">
        {{ message }}
      </div>

      <div v-if="isLoading" class="loading-container">
        <p>Loading records from web service...</p>
      </div>

      <div v-else-if="records.length === 0" class="empty-state">
        <h3>No Records Found</h3>
        <p>
          There are no records in the database yet. Start by adding some records via the Web
          Service.
        </p>
        <button @click="$router.push('/webservice/add')" class="btn">
          Add First Record via Web Service
        </button>
      </div>

      <div v-else class="table-container">
        <table class="records-table">
          <thead>
            <tr>
              <th>Name</th>
              <th>Surname</th>
              <th>Age</th>
              <th>Email</th>
              <th>Phone</th>
            </tr>
          </thead>
          <tbody>
            <tr
              v-for="record in records"
              :key="record.id || `${record.name}-${record.phoneNumber}`"
            >
              <td>{{ record.name }}</td>
              <td>{{ record.surname }}</td>
              <td>{{ record.age }}</td>
              <td>
                <a :href="`mailto:${record.email}`" class="link">
                  {{ record.email }}
                </a>
              </td>
              <td>
                <a :href="`tel:${record.phoneNumber}`" class="link">
                  {{ record.phoneNumber }}
                </a>
              </td>
            </tr>
          </tbody>
        </table>
      </div>

      <div v-if="records.length > 0" class="table-footer">
        <p>
          Total Records: <strong>{{ records.length }}</strong>
        </p>
      </div>
    </div>
  </div>
</template>

<style scoped>
.list-records-container {
  max-width: 1000px;
  margin: 0 auto;
  padding: 1rem;
}

.list-card {
  background: white;
  border: 1px solid #ddd;
  border-radius: 8px;
  padding: 1.5rem;
}

.list-header {
  display: flex;
  justify-content: space-between;
  align-items: center;
  margin-bottom: 1.5rem;
  flex-wrap: wrap;
  gap: 1rem;
}

h1 {
  color: #333;
  font-size: 1.5rem;
  margin: 0;
  font-weight: bold;
}

.message {
  padding: 0.75rem;
  border-radius: 4px;
  margin-bottom: 1rem;
  font-size: 0.9rem;
}

.message.success {
  background-color: #d4edda;
  color: #155724;
  border: 1px solid #c3e6cb;
}

.message.error {
  background-color: #f8d7da;
  color: #721c24;
  border: 1px solid #f5c6cb;
}

.loading-container {
  display: flex;
  justify-content: center;
  padding: 2rem;
  color: #666;
}

.empty-state {
  text-align: center;
  padding: 2rem;
  color: #666;
}

.empty-state h3 {
  color: #333;
  margin-bottom: 1rem;
  font-size: 1.2rem;
}

.empty-state p {
  margin-bottom: 1.5rem;
}

.table-container {
  overflow-x: auto;
  border: 1px solid #ddd;
  border-radius: 4px;
}

.records-table {
  width: 100%;
  border-collapse: collapse;
  background: white;
}

.records-table th {
  background-color: #f8f9fa;
  color: #333;
  padding: 0.75rem;
  text-align: left;
  font-weight: bold;
  font-size: 0.9rem;
  border-bottom: 1px solid #ddd;
}

.records-table td {
  padding: 0.75rem;
  border-bottom: 1px solid #eee;
  color: #333;
  font-size: 0.9rem;
}

.records-table tbody tr:hover {
  background-color: #f8f9fa;
}

.records-table tbody tr:last-child td {
  border-bottom: none;
}

.link {
  color: #007bff;
  text-decoration: none;
}

.link:hover {
  text-decoration: underline;
}

.table-footer {
  margin-top: 1rem;
  padding-top: 1rem;
  border-top: 1px solid #ddd;
  text-align: center;
  color: #666;
}

.btn {
  padding: 0.5rem 1rem;
  border: 1px solid #007bff;
  border-radius: 4px;
  background-color: #007bff;
  color: white;
  cursor: pointer;
  font-size: 0.9rem;
}

.btn:hover:not(:disabled) {
  background-color: #0056b3;
}

.btn:disabled {
  cursor: not-allowed;
  opacity: 0.6;
}

@media (max-width: 768px) {
  .list-records-container {
    padding: 0.5rem;
  }

  .list-card {
    padding: 1rem;
  }

  .list-header {
    flex-direction: column;
    text-align: center;
  }

  h1 {
    font-size: 1.2rem;
  }

  .records-table {
    font-size: 0.8rem;
  }

  .records-table th,
  .records-table td {
    padding: 0.5rem 0.25rem;
  }
}
</style>
