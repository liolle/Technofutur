import { defineConfig } from 'vite'
import path from 'path';

// https://vitejs.dev/config/
export default defineConfig({
  resolve: {
    alias: {
      '@': path.resolve(__dirname, './src'),
    },
  },
  plugins: [
    {
      name: 'html-import',
      transform(src, id) {
        if (id.endsWith('.html')) {
          return `export default ${JSON.stringify(src)}`;
        }
      },
    },
  ]
})
