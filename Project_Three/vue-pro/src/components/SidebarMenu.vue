<script setup lang="ts">
import { ref } from 'vue'
import { useRouter } from 'vue-router'

const router = useRouter()
const activeSection = ref('entity')

const menuItems = [
  {
    title: 'Entity Management',
    children: [
      { name: 'Add Record', path: '/entity/add' },
      { name: 'Delete Record', path: '/entity/delete' },
      { name: 'List Records', path: '/entity/list' },
      { name: 'Search Records', path: '/entity/search' }
    ]
  },
  {
    title: 'Web Service Operations',
    children: [
      { name: 'Add Record', path: '/webservice/add' },
      { name: 'Delete Record', path: '/webservice/delete' },
      { name: 'List Records', path: '/webservice/list' },
      { name: 'Search Records', path: '/webservice/search' }
    ]
  }
]

const toggleSection = (title: string) => {
  activeSection.value = activeSection.value === title ? '' : title
}

const navigateTo = (path: string) => {
  router.push(path)
}
</script>

<template>
  <aside class="sidebar">
    <div class="sidebar-header">
      <h2>Phone Book</h2>
    </div>
    
    <nav class="sidebar-nav">
      <div v-for="item in menuItems" :key="item.title" class="menu-section">
        <button 
          @click="toggleSection(item.title)"
          class="menu-header"
          :class="{ active: activeSection === item.title }"
        >
          <span class="menu-title">{{ item.title }}</span>
          <span class="menu-arrow" :class="{ rotated: activeSection === item.title }">
            ▼
          </span>
        </button>
        
        <div v-show="activeSection === item.title" class="menu-children">
          <button
            v-for="child in item.children"
            :key="child.path"
            @click="navigateTo(child.path)"
            class="menu-child"
            :class="{ active: $route.path === child.path }"
          >
            {{ child.name }}
          </button>
        </div>
      </div>
    </nav>
  </aside>
</template>

<style scoped>
.sidebar {
  width: 250px;
  background-color: #f5f5f5;
  border-right: 1px solid #ddd;
}

.sidebar-header {
  padding: 1rem;
  border-bottom: 1px solid #ddd;
}

.sidebar-header h2 {
  font-size: 1.2rem;
  font-weight: bold;
  margin: 0;
  text-align: center;
}

.sidebar-nav {
  padding: 0.5rem 0;
}

.menu-section {
  margin-bottom: 0.25rem;
}

.menu-header {
  width: 100%;
  padding: 0.75rem 1rem;
  background: none;
  border: none;
  cursor: pointer;
  display: flex;
  align-items: center;
  justify-content: space-between;
  font-size: 0.9rem;
  transition: background-color 0.2s;
}

.menu-header:hover {
  background-color: #e9ecef;
}

.menu-header.active {
  background-color: #dee2e6;
}

.menu-title {
  font-weight: 500;
}

.menu-arrow {
  font-size: 0.7rem;
  transition: transform 0.2s;
}

.menu-arrow.rotated {
  transform: rotate(180deg);
}

.menu-children {
  background-color: #fff;
}

.menu-child {
  width: 100%;
  padding: 0.5rem 1rem 0.5rem 2rem;
  background: none;
  border: none;
  cursor: pointer;
  text-align: left;
  font-size: 0.85rem;
  transition: background-color 0.2s;
  border-left: 3px solid transparent;
}

.menu-child:hover {
  background-color: #f8f9fa;
}

.menu-child.active {
  background-color: #e3f2fd;
  border-left-color: #2196f3;
}
</style>
