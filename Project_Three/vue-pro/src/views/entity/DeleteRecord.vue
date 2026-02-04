<script setup lang="ts">
import { ref } from 'vue'
import { recordService } from '../../services/api'

const searchQuery = ref('')
const isDeleting = ref(false)
const message = ref('')
const messageType = ref<'success' | 'error' | ''>('')

const showMessage = (msg: string, type: 'success' | 'error') => {
  message.value = msg
  messageType.value = type
  setTimeout(() => {
    message.value = ''
    messageType.value = ''
  }, 3000)
}

const handleDelete = async () => {
  if (!searchQuery.value.trim()) {
    showMessage('Please enter a name to delete', 'error')
    return
  }

  isDeleting.value = true
  try {
    await recordService.deleteRecord(searchQuery.value.trim())
    showMessage('Record deleted successfully!', 'success')
    searchQuery.value = ''
  } catch (error) {
    console.error('Error deleting record:', error)
    showMessage('Failed to delete record. Please check if the record exists.', 'error')
  } finally {
    isDeleting.value = false
  }
}
</script>

<template>
  <div class="delete-record-container">
    <div class="form-card">
      <h1>Delete Record - Entity Management</h1>
      
      <div v-if="message" :class="['message', messageType]">
        {{ message }}
      </div>

      <div class="delete-warning">
        <h3>Warning</h3>
        <p>This action will permanently delete the record. Please enter the name of the record you want to delete.</p>
      </div>

      <form @submit.prevent="handleDelete" class="delete-form">
        <div class="form-group">
          <label for="searchQuery">Name *</label>
          <input
            id="searchQuery"
            v-model="searchQuery"
            type="text"
            required
            placeholder="Enter name to delete"
            :disabled="isDeleting"
          />
          <small class="form-hint">Enter the person's name to identify the record to delete.</small>
        </div>

        <div class="form-actions">
          <button
            type="submit"
            class="btn btn-danger"
            :disabled="isDeleting || !searchQuery.trim()"
          >
            {{ isDeleting ? 'Deleting...' : 'Delete Record' }}
          </button>
          
          <button
            type="button"
            class="btn btn-secondary"
            @click="searchQuery = ''"
            :disabled="isDeleting"
          >
            Clear
          </button>
        </div>
      </form>
    </div>
  </div>
</template>

<style scoped>
.delete-record-container {
  max-width: 500px;
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

.delete-warning {
  background-color: #fff3cd;
  border: 1px solid #ffeaa7;
  border-radius: 4px;
  padding: 1rem;
  margin-bottom: 1.5rem;
}

.delete-warning h3 {
  color: #856404;
  margin: 0 0 0.5rem 0;
  font-size: 1rem;
  font-weight: bold;
}

.delete-warning p {
  color: #856404;
  margin: 0;
  font-size: 0.9rem;
}

.delete-form {
  display: flex;
  flex-direction: column;
  gap: 1rem;
}

.form-group {
  display: flex;
  flex-direction: column;
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
  border-color: #dc3545;
}

input:disabled {
  background-color: #f5f5f5;
  cursor: not-allowed;
}

.form-hint {
  color: #666;
  font-size: 0.8rem;
  margin-top: 0.25rem;
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

.btn-danger {
  background-color: #dc3545;
  border-color: #dc3545;
}

.btn-danger:hover:not(:disabled) {
  background-color: #c82333;
}

.btn-secondary {
  background-color: #6c757d;
  border-color: #6c757d;
}

.btn-secondary:hover:not(:disabled) {
  background-color: #545b62;
}

@media (max-width: 768px) {
  .delete-record-container {
    padding: 0.5rem;
  }
  
  .form-card {
    padding: 1rem;
  }
  
  .form-actions {
    flex-direction: column;
  }
  
  .btn {
    width: 100%;
  }
}
</style>
