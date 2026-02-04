<script setup lang="ts">
import { ref } from "vue";
import { recordService, type Record } from "../../services/api";

const formData = ref<Record>({
  name: "",
  surname: "",
  age: 0,
  email: "",
  PhoneNumber: "",
});

const isSubmitting = ref(false);
const message = ref("");
const messageType = ref<"success" | "error" | "">("");

const validateForm = () => {
  if (!formData.value.name.trim()) {
    showMessage("Name is required", "error");
    return false;
  }
  if (!formData.value.surname.trim()) {
    showMessage("Surname is required", "error");
    return false;
  }
  if (!formData.value.email.trim()) {
    showMessage("Email is required", "error");
    return false;
  }
  if (!formData.value.PhoneNumber.trim()) {
    showMessage("Phone number is required", "error");
    return false;
  }
  if (formData.value.age <= 0 || formData.value.age > 120) {
    showMessage("Please enter a valid age", "error");
    return false;
  }
  const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
  if (!emailRegex.test(formData.value.email)) {
    showMessage("Please enter a valid email address", "error");
    return false;
  }
  return true;
};

const showMessage = (msg: string, type: "success" | "error") => {
  message.value = msg;
  messageType.value = type;
  setTimeout(() => {
    message.value = "";
    messageType.value = "";
  }, 3000);
};

const handleSubmit = async () => {
  if (!validateForm()) return;

  isSubmitting.value = true;
  try {
    await recordService.addRecord(formData.value);
    showMessage("Record added successfully!", "success");
    formData.value = {
      name: "",
      surname: "",
      age: 0,
      email: "",
      PhoneNumber: "",
    };
  } catch (error) {
    console.error("Error adding record:", error);
    showMessage("Failed to add record. Please try again.", "error");
  } finally {
    isSubmitting.value = false;
  }
};
</script>

<template>
  <div class="add-record-container">
    <div class="form-card">
      <h1>Add Record - Entity Management</h1>

      <div v-if="message" :class="['message', messageType]">
        {{ message }}
      </div>

      <form @submit.prevent="handleSubmit" class="record-form">
        <div class="form-row">
          <div class="form-group">
            <label for="name">Name *</label>
            <input
              id="name"
              v-model="formData.name"
              type="text"
              required
              placeholder="Enter name"
              :disabled="isSubmitting"
            />
          </div>

          <div class="form-group">
            <label for="surname">Surname *</label>
            <input
              id="surname"
              v-model="formData.surname"
              type="text"
              required
              placeholder="Enter surname"
              :disabled="isSubmitting"
            />
          </div>
        </div>

        <div class="form-row">
          <div class="form-group">
            <label for="age">Age *</label>
            <input
              id="age"
              v-model.number="formData.age"
              type="number"
              min="1"
              max="120"
              required
              placeholder="Enter age"
              :disabled="isSubmitting"
            />
          </div>

          <div class="form-group">
            <label for="phone">Phone Number *</label>
            <input
              id="phone"
              v-model="formData.PhoneNumber"
              type="tel"
              required
              placeholder="Enter phone number"
              :disabled="isSubmitting"
            />
          </div>
        </div>

        <div class="form-group full-width">
          <label for="email">Email *</label>
          <input
            id="email"
            v-model="formData.email"
            type="email"
            required
            placeholder="Enter email address"
            :disabled="isSubmitting"
          />
        </div>

        <div class="form-actions">
          <button type="submit" class="btn" :disabled="isSubmitting">
            {{ isSubmitting ? "Adding..." : "Add Record" }}
          </button>

          <button
            type="button"
            class="btn btn-secondary"
            @click="formData = { name: '', surname: '', age: 0, email: '', PhoneNumber: '' }"
            :disabled="isSubmitting"
          >
            Clear Form
          </button>
        </div>
      </form>
    </div>
  </div>
</template>

<style scoped>
.add-record-container {
  max-width: 700px;
  margin: 0 auto;
  padding: 1rem;
}

.form-card {
  background: white;
  border: 1px solid #ddd;
  border-radius: 8px;
  padding: 1.5rem;
}

h1 {
  color: #333;
  font-size: 1.5rem;
  margin-bottom: 1.5rem;
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

.record-form {
  display: flex;
  flex-direction: column;
  gap: 1rem;
}

.form-row {
  display: grid;
  grid-template-columns: 1fr 1fr;
  gap: 1rem;
}

.form-group {
  display: flex;
  flex-direction: column;
}

.form-group.full-width {
  grid-column: 1 / -1;
}

label {
  font-weight: bold;
  color: #333;
  margin-bottom: 0.25rem;
  font-size: 0.9rem;
}

input {
  padding: 0.5rem;
  border: 1px solid #ccc;
  border-radius: 4px;
  font-size: 0.9rem;
  background-color: #fff;
}

input:focus {
  outline: none;
  border-color: #007bff;
}

input:disabled {
  background-color: #f5f5f5;
  cursor: not-allowed;
}

.form-actions {
  display: flex;
  gap: 1rem;
  margin-top: 1rem;
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

.btn-secondary {
  background-color: #6c757d;
  border-color: #6c757d;
}

.btn-secondary:hover:not(:disabled) {
  background-color: #545b62;
}

@media (max-width: 768px) {
  .add-record-container {
    padding: 0.5rem;
  }

  .form-card {
    padding: 1rem;
  }

  .form-row {
    grid-template-columns: 1fr;
    gap: 0.5rem;
  }

  .form-actions {
    flex-direction: column;
  }

  .btn {
    width: 100%;
  }
}
</style>
