<script setup lang="ts">
import { useRouter } from 'vue-router'

const router = useRouter()

const navigateToSection = (path: string) => {
  router.push(path)
}
</script>

<template>
  <div class="home-container">
    <div class="welcome-card">
      <h1>Phone Book Management</h1>
      <p>Manage your contacts with Entity Management and Web Service Operations</p>
      
      <div class="quick-actions">
        <div class="action-section">
          <h2>Entity Management</h2>
          <div class="action-buttons">
            <button @click="navigateToSection('/entity/add')" class="btn">
              Add Record
            </button>
            <button @click="navigateToSection('/entity/delete')" class="btn">
              Delete Record
            </button>
            <button @click="navigateToSection('/entity/list')" class="btn">
              List Records
            </button>
            <button @click="navigateToSection('/entity/search')" class="btn">
              Search Records
            </button>
          </div>
        </div>
        
        <div class="action-section">
          <h2>Web Service Operations</h2>
          <div class="action-buttons">
            <button @click="navigateToSection('/webservice/add')" class="btn">
              Add Record
            </button>
            <button @click="navigateToSection('/webservice/delete')" class="btn">
              Delete Record
            </button>
            <button @click="navigateToSection('/webservice/list')" class="btn">
              List Records
            </button>
            <button @click="navigateToSection('/webservice/search')" class="btn">
              Search Records
            </button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<style scoped>
.home-container {
  display: flex;
  justify-content: center;
  align-items: flex-start;
  min-height: calc(100vh - 2rem);
  padding: 1rem;
}

.welcome-card {
  background: white;
  border: 1px solid #ddd;
  border-radius: 8px;
  padding: 2rem;
  max-width: 800px;
  width: 100%;
  text-align: center;
}

h1 {
  color: #333;
  font-size: 1.8rem;
  margin-bottom: 1rem;
  font-weight: bold;
}

p {
  color: #666;
  font-size: 1rem;
  margin-bottom: 2rem;
}

.quick-actions {
  display: grid;
  grid-template-columns: repeat(auto-fit, minmax(350px, 1fr));
  gap: 1.5rem;
  margin-top: 1rem;
}

.action-section {
  background: #f9f9f9;
  border: 1px solid #eee;
  border-radius: 6px;
  padding: 1.5rem;
}

.action-section h2 {
  color: #444;
  font-size: 1.2rem;
  margin-bottom: 1rem;
  font-weight: bold;
}

.action-buttons {
  display: grid;
  grid-template-columns: 1fr;
  gap: 0.5rem;
}

.btn {
  padding: 0.75rem 1rem;
  border: 1px solid #ccc;
  border-radius: 4px;
  background-color: #fff;
  color: #333;
  cursor: pointer;
  font-size: 0.9rem;
  transition: background-color 0.2s;
}

.btn:hover {
  background-color: #f0f0f0;
}

@media (max-width: 768px) {
  .home-container {
    padding: 0.5rem;
  }
  
  .welcome-card {
    padding: 1rem;
  }
  
  h1 {
    font-size: 1.5rem;
  }
  
  .quick-actions {
    grid-template-columns: 1fr;
    gap: 1rem;
  }
}
</style>
