import { inject, ref, onMounted, computed } from "vue"
import { QueryInvoices } from "/types/mjs"

export const Welcome = {
    template:/*html*/`
    <div class="pl-4">
        <h1 class="text-3xl">
            Welcome to Chinook Locode
        </h1>
        <div v-if="lastOrders.length" class="mt-8">
            <h3 class="text-xl mb-4">Here are your last {{lastOrders.length}} orders:</h3>
            <DataGrid class="max-w-screen-md" type="Invoices" :items="lastOrders" tableStyle="uppercaseHeadings" />
        </div>
    </div>`,
    setup() {
        const client = inject('client')
        const api = ref()
        const lastOrders = computed(() => api.value?.response?.results || [])
        
        onMounted(async () => {
            api.value = await client.api(new QueryInvoices({ 
                orderBy:'-InvoiceId',
                take:5,
                fields:'InvoiceId,CustomerId,InvoiceDate,Total,BillingCountry,BillingCity'
            }), { jsconfig: 'edv' })
        })
        
        return { lastOrders }
    }
}
