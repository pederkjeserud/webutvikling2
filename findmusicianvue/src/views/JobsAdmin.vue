<template>

    <header>
        <h1>Oppdrag Admin</h1>
    </header>

    <section class="admin-create">
        <jobsAdmin-create></jobsAdmin-create>
    </section>

    <section class="admin-update">
        <jobsAdmin-update></jobsAdmin-update>
    </section>

    <section class="admin-delete">
        <jobsAdmin-delete></jobsAdmin-delete>
    </section>
    
</template>

<script>
import JobsAdminCreate from '../components/jobsAdmin/JobsAdminCreate'
import JobsAdminUpdate from '../components/jobsAdmin/JobsAdminUpdate'
import JobsAdminDelete from '../components/jobsAdmin/JobsAdminDelete'

export default {
    components: { 
        JobsAdminCreate, 
        JobsAdminUpdate,
        JobsAdminDelete
    }
}
</script>