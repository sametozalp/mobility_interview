<script setup lang="ts">
import { RouterView } from 'vue-router'
import SidebarMenu from './components/SidebarMenu.vue'
</script>

<template>
  <div class="app-container">
    <SidebarMenu />
    <main class="main-content">
      <RouterView />
    </main>
  </div>
</template>

<style>
* {
  margin: 0;
  padding: 0;
  box-sizing: border-box;
}

body {
  font-family: Arial, sans-serif;
  background-color: #fafafa;
}

.app-container {
  display: flex;
  min-height: 100vh;
}

.main-content {
  flex: 1;
  padding: 1rem;
  background-color: #fff;
}
</style>
