<script setup lang="ts">
import { ref } from 'vue'
import { recordService, type Record } from '../../services/api'

const searchQuery = ref('')
const searchResults = ref<Record[]>([])
const isSearching = ref(false)
const hasSearched = ref(false)
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

const handleSearch = async () => {
  if (!searchQuery.value.trim()) {
    showMessage('Please enter a search term', 'error')
    return
  }

  isSearching.value = true
  hasSearched.value = true
  
  try {
    const results = await recordService.searchRecords(searchQuery.value.trim())
    searchResults.value = results
    
    if (results.length === 0) {
      showMessage('No records found matching your search', 'error')
    } else {
      showMessage(`Found ${results.length} record(s) matching "${searchQuery.value}"`, 'success')
    }
  } catch (error) {
    console.error('Error searching records:', error)
    showMessage('Failed to search records. Please try again.', 'error')
    searchResults.value = []
  } finally {
    isSearching.value = false
  }
}

const clearSearch = () => {
  searchQuery.value = ''
  searchResults.value = []
  hasSearched.value = false
  message.value = ''
  messageType.value = ''
}
</script>

<template>
  <div class="search-records-container">
    <div class="search-card">
      <h1>Search Records - Entity Management</h1>
      
      <div v-if="message" :class="['message', messageType]">
        {{ message }}
      </div>

      <form @submit.prevent="handleSearch" class="search-form">
        <div class="search-input-group">
          <div class="form-group">
            <label for="searchQuery">Search by Name</label>
            <input
              id="searchQuery"
              v-model="searchQuery"
              type="text"
              placeholder="Enter name to search..."
              :disabled="isSearching"
              @keyup.enter="handleSearch"
            />
            <small class="form-hint">Search for records by name. The search is case-insensitive.</small>
          </div>
        </div>

        <div class="form-actions">
          <button
            type="submit"
            class="btn"
            :disabled="isSearching || !searchQuery.trim()"
          >
            {{ isSearching ? 'Searching...' : 'Search' }}
          </button>
          
          <button
            type="button"
            class="btn btn-secondary"
            @click="clearSearch"
            :disabled="isSearching"
          >
            Clear
          </button>
        </div>
      </form>

      <div v-if="isSearching" class="loading-container">
        <p>Searching records...</p>
      </div>

      <div v-else-if="hasSearched && searchResults.length === 0" class="no-results">
        <h3>No Results Found</h3>
        <p>No records match your search for "{{ searchQuery }}". Try a different search term.</p>
      </div>

      <div v-else-if="searchResults.length > 0" class="results-container">
        <div class="results-header">
          <h3>Search Results</h3>
          <span class="results-count">{{ searchResults.length }} record(s) found</span>
        </div>

        <div class="table-container">
          <table class="results-table">
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
              <tr v-for="record in searchResults" :key="record.id || `${record.name}-${record.phone}`">
                <td>
                  <span class="highlighted-name">{{ record.name }}</span>
                </td>
                <td>{{ record.surname }}</td>
                <td>{{ record.age }}</td>
                <td>
                  <a :href="`mailto:${record.email}`" class="link">
                    {{ record.email }}
                  </a>
                </td>
                <td>
                  <a :href="`tel:${record.phone}`" class="link">
                    {{ record.phone }}
                  </a>
                </td>
              </tr>
            </tbody>
          </table>
        </div>
      </div>
    </div>
  </div>
</template>

<style scoped>
.search-records-container {
  max-width: 1000px;
  margin: 0 auto;
  padding: 1rem;
}

.search-card {
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
}

.message.error {
  background-color: #f8d7da;
  color: #721c24;
  border: 1px solid #f5c6cb;
}

.search-form {
  margin-bottom: 1.5rem;
}

.search-input-group {
  margin-bottom: 1rem;
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
  border-color: #007bff;
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

.loading-container {
  display: flex;
  justify-content: center;
  padding: 2rem;
  color: #666;
}

.no-results {
  text-align: center;
  padding: 2rem;
  color: #666;
}

.no-results h3 {
  color: #333;
  margin-bottom: 1rem;
  font-size: 1.2rem;
}

.no-results p {
  margin-bottom: 0;
}

.results-container {
  margin-top: 1.5rem;
}

.results-header {
  display: flex;
  justify-content: space-between;
  align-items: center;
  margin-bottom: 1rem;
  padding-bottom: 0.5rem;
  border-bottom: 1px solid #ddd;
}

.results-header h3 {
  color: #333;
  margin: 0;
  font-size: 1.2rem;
  font-weight: bold;
}

.results-count {
  background-color: #007bff;
  color: white;
  padding: 0.25rem 0.75rem;
  border-radius: 12px;
  font-size: 0.8rem;
  font-weight: bold;
}

.table-container {
  overflow-x: auto;
  border: 1px solid #ddd;
  border-radius: 4px;
}

.results-table {
  width: 100%;
  border-collapse: collapse;
  background: white;
}

.results-table th {
  background-color: #f8f9fa;
  color: #333;
  padding: 0.75rem;
  text-align: left;
  font-weight: bold;
  font-size: 0.9rem;
  border-bottom: 1px solid #ddd;
}

.results-table td {
  padding: 0.75rem;
  border-bottom: 1px solid #eee;
  color: #333;
  font-size: 0.9rem;
}

.results-table tbody tr:hover {
  background-color: #f8f9fa;
}

.results-table tbody tr:last-child td {
  border-bottom: none;
}

.highlighted-name {
  font-weight: bold;
  color: #007bff;
}

.link {
  color: #007bff;
  text-decoration: none;
}

.link:hover {
  text-decoration: underline;
}

@media (max-width: 768px) {
  .search-records-container {
    padding: 0.5rem;
  }
  
  .search-card {
    padding: 1rem;
  }
  
  h1 {
    font-size: 1.2rem;
  }
  
  .form-actions {
    flex-direction: column;
  }
  
  .btn {
    width: 100%;
  }
  
  .results-header {
    flex-direction: column;
    gap: 0.5rem;
    text-align: center;
  }
  
  .results-table {
    font-size: 0.8rem;
  }
  
  .results-table th,
  .results-table td {
    padding: 0.5rem 0.25rem;
  }
}
</style>
